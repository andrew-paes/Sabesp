// cria o obejto ag2 caso o mesmo n�o exista
if (typeof ag2 == "undefined") var ag2 = new Object();

/**
* Construtor.
*/
ag2.UploadApi = function() {
    // identificador do componente, gerado automaticamente
    this.id = "";
    // arquivo respons�vel pelo upload
    this.action = "../upload.aspx";
    // caminho onde dever� ser salvo/carregado os arquivos
    this.path = "";
    //Caminho base para o diretorio de upload
    this.baseUrlUpload = "";
    // nome do arquivo, para quando j� existe um elemento carregado
    this.fileName = "";
    // tamanho m�ximo do arquiv em Kb
    this.maxSize = null;
    // largura maxima do arquivo em pixels, quando imagem
    this.maxWidth = null;
    // altura m�xima do arquivo, quando imagem
    this.maxHeight = null;
    // filtros para caixa de dialogo
    this.filters = new Array();
    // armazena a instancia para futura consulta	
    ag2.UploadApi.instances.push(this);
}


// Armazena todas as inst�ncias de objetos
// Utilizado para implementar a busca de objetos a partir do flash sem a necessidade do uso de callBack
// pois para isso seriam necess�rias personalizar implementa��es de seguran�a para cada dom�nio onde fosse utilizado
ag2.UploadApi.instances = new Array();



/**
* Gera de forma autom�tica um identificador para o componente
*/
ag2.UploadApi.generateComponenteId = function() {
    return Math.round(Math.random() * (new Date()).getTime());
}


/**
* Recupera a inst�ncia JS de um dado componente
* @param componentId Identificador do componente
*/
ag2.UploadApi.getInstance = function(componentId) {
    var instance;
    for (var i = 0; i < ag2.UploadApi.instances.length; i++) {
        if (ag2.UploadApi.instances[i].id == componentId) {
            instance = ag2.UploadApi.instances[i];
            break;
        }
    }
    return instance;
}

ag2.UploadApi.prototype =
{
    /**
    * Seta filtros de arquivos para a caixa de dialogo de sele��o
    * @param labbel String que vai aparecer na lista de arquivos dispon�veis. Ex: "Imagens (*.jpg)"
    * @param extensions String com as extens�es de arquivos permitidas, se mais de uma, devem ser divididas com (;). Ex: *.jpg; *.gif
    */
    addFilter: function(label, extensions) {
        var element = label + " | " + extensions;
        this.filters.push(element);
    },
    /**
    * M�todo chamado pelo flash quando o usu�rio clica no bot�o de excluir arquivo.
    */
    deleteFile: function() {

        var arq = this.path + "/" + document.getElementById(this.id + "_fileName").value;
        var control = document.getElementById(this.id + "_fileName");

        $.ajax({
            type: "POST",
            url: "../File.aspx/DeleteFile",
            data: "{'path':'" + arq + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(msg) {
                if (msg.d) { // Se retornar true apaga o valor do campo.
                    control.value = "";
                }
            }
        });

    },
    /**
    * M�todo chamado pelo flash quando o �suario clica no bot�o para procurar o arquivo
    */
    onBrowse: function() {
        this.objFlash = (navigator.appName.indexOf("Microsoft") != -1) ? $(this.id) : document[this.id];
        this.objFlash.initFlashAPI(ag2.UploadApiUtil.getInstance(this.id));

        //alert("onBrowse: " + this.id);

    },
    /**
    * M�todo acionado quando o arquivo � selecionado e a caixa de di�logo � fechada
    * @param fileName Nome do arquivo
    */
    onSelect: function(fileName) {
        // vai fazer upload
        // apagar anterior?
        this.fileName = fileName;
        //alert("Arquivo selecionado: " + fileName + "\nComponente: " + this.id);
    },
    /**
    * M�todo acionado quando o upload � iniciado
    */
    onStart: function() {
        //alert("Iniciou carregamento: " + this.fileName + "\nComponente: " + this.id);
    },
    /**
    * M�todo acionado pelo flash durante o progresso do carregamento
    * @param totalBytes Tamanho do arquivo em bytes
    * @param totalLoaded Total de bytes carregados
    */
    onProgress: function(totalBytes, totalLoaded) {
        //alert("Progresso: " + this.fileName + "\nComponente: " + this.id + "\nTamanho: " + totalBytes + "\nCarregado: " + totalLoaded);
    },
    /**
    * M�todo acionado quando existe algum tipo de falha no upload informado pelo flash, 
    * sendo que os erros previstos s�o:	* -100 | Security Error,  -200 | Io Error,  -300 | Size Error.
    * @param errorId C�digo do error
    */
    onError: function(errorId) {

        if (errorId == "-300") {
            alert("Tamanho do arquivo excedeu o limite.");
        }
        else {
            alert("\nComponente: " + this.id + "\nErro: " + errorId);
        }
    },
    /**
    * M�todo acionado pelo flash quando o carregamento � finalizado
    * @param componentId Identificador do componente
    * @param fileName Nome do arquivo
    */
    onComplete: function() {
        var _temp = this;

        $.ajax({
            type: "POST",
            url: "../File.aspx/ImageInfo",
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(r) {
                var obj;
                if (r.d != undefined)
                    obj = r.d;
                else
                    obj = r;

                if (obj.Error != "") {
                    alert(obj.Error);
                }

                document.getElementById(_temp.id + "_fileName").value = obj.Name;
            }
        });

    },
    /**
    * M�todo acionado pelo flash quando o carregamento � finalizado e os dados est�o prontos para uso
    * @param componentId Identificador do componente
    * @param fileName Nome do arquivo
    */
    onCompleteData: function() {
        //alert("Arquivo ccompleto: " + this.fileName + "\nComponente: " + this.componentId);
    },
    /**
    * M�todo utilizado para escrever o flash no html. Utiliza a biblioteca SWF Object como auxiliar
    * @param div Id da div onde o objeto ser� escrito
    */
    write: function(div) {
        var ag2Upload = new SWFObject("../swf/ag2_uploadapi.swf", this.id, "550", "200", "9");
        ag2Upload.addParam("wmode", "transparent");
        ag2Upload.addParam("quality", "high");
        // tamanho m�ximo do arquivo
        ag2Upload.addVariable("componentId", this.id);
        // action - path da pagina responsavel pelo upload
        ag2Upload.addVariable("action", this.action);
        // tamanho m�ximo do arquivo
        ag2Upload.addVariable("fileName", this.fileName);
        // diret�rio onde o arquivo ser�/foi salvo
        ag2Upload.addVariable("path", this.path);
        //Caminho base para o diretorio de upload
        ag2Upload.addVariable("baseUrlUpload", this.baseUrlUpload);
        // tamanho m�ximo do arquivo em kb
        ag2Upload.addVariable("maxSize", this.maxSize);
        // largura m�xima
        ag2Upload.addVariable("maxWidth", this.maxWidth);
        // altura m�xima
        ag2Upload.addVariable("maxHeight", this.maxHeight);
        // a descri��o deve ser separada das exten��es por pipe ( | )
        // as exten��es possiveis devem ser separadas por ;
        for (var i = 0; i < this.filters.length; i++)
            ag2Upload.addVariable("filter" + i, this.filters[i]);
        // escreve o obejto flash
        ag2Upload.write(div);
    }
}