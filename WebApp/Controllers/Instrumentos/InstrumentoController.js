App.Controllers.controller('InstrumentoListController', function ($window, $scope, $state, $stateParams, myService, Instrumento) {
    Instrumento.query({},
        function (data) {
            $scope.instrumentos = data;
        },
        function (data) {
            myService.ShowAlert(data);
    });
}).controller('InstrumentoDetailsController', function ($window, $scope, $state, $stateParams, myService, Instrumento) {
    $scope.serviceBase = serviceBase;

    Instrumento.get({ Id: $stateParams.Id },
        function (data) {
            $scope.instrumento = data;
            $('#tdAudio').html('<audio controls src="' + serviceBase + data.Som + '" />');
        }, 
        function (data) {
            myService.ShowAlert(data);
        });

    $scope.deleteInstrumento = function (item) {
        $scope.instrumento = item;
        if ($window.navigator.notification==null) {
            if ($window.confirm('Deseja realmente excluir esse instrumento?')) {
                $scope.delete();
            }
        }
        else {
            $window.notification.confirm(
                'Deseja realmente excluir esse instrumento?',
                $scope.onConfirm,
                'EXCLUSÃO',
                'Sim,Não');
        }
    };
    $scope.onConfirm = function (button) {
        if (button == 1) {
            $scope.delete();
        }
    };

    $scope.delete = function () {
        $scope.instrumento.$delete(function () {
            $state.go('listInstrumentos');
        }, function (data) {
            myService.ShowAlert(data);
        });
    };
}).controller('InstrumentoCreateController', function ($window, $scope, $state, $stateParams, myService, Instrumento) {

    $scope.instrumento = new Instrumento();

    $scope.imagemChanged = function (elm) {
        if (elm.files.length > 0) {
            var selectedFile = elm.files[0];
            selectedFile.convertToBase64(function (base64) {
                $scope.instrumento.Imagem = selectedFile.name + '|' + base64;
            });
        }
    };

    $scope.somChanged = function (elm) {
        if (elm.files.length > 0) {
            var selectedFile = elm.files[0];
            selectedFile.convertToBase64(function (base64) {
                $scope.instrumento.Som = selectedFile.name + '|' + base64;
            });
        }
    };

    $scope.addInstrumento = function () {

        $scope.instrumento.$save(function () {

            myService.ShowAlert('listInstrumentos');

        }, function (data) {
            myService.ShowAlert(data);
        });
    }

}).controller('InstrumentoEditController', function ($window, $scope, $state, $stateParams, myService, Instrumento) {
    $scope.exibir = true;
    
    $scope.updateInstrumento = function () {
        $scope.instrumento.$update(
            function () {
                myService.ShowAlert('listInstrumentos');
            },
            function (data) {
                myService.ShowAlert(data);
        });
    };

    $scope.loadInstrumento = function () {
        $scope.instrumento = Instrumento.get({Id: $stateParams.Id});
    };

    $scope.loadInstrumento();
});