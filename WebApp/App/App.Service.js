App.Services.service('myService', function ($http, $window, $state) {
    $($window.document).ready(function () {
        $('[data-toggle="tooltip"]').tooltip();
        $('[data-toggle="popover"]').tooltip();
    });

    this.ShowSucesso = function () {
        if ($window.navigator.notification == null) {
            $('#msgSucesso').fadeIn('slow');
            $('#msgSucesso').delay(1000).fadeOut('slow');
        }
        else {
            $window.navigator.notification.alert(
                'Ação realizada com sucesso!',
                null,
                'SUCESSO!',
                'OK');
        }
    };

    this.ShowAviso = function (htmlMessage) {
        if ($window.navigator.notification == null) {
            $('#spanMsgAviso').html(htmlMessage);
            $('#msgAviso').fadeIn('slow');
            $('#msgAviso').delay(3000).fadeOut('slow');
        }
        else {
            $window.navigator.notification.alert(
                $(htmlMessage).text(),
                null,
                'AVISO!',
                'OK');
        }
    };

    this.ShowErro = function (htmlMessage) {
        if ($window.navigator.notification == null) {
            $('#spanMsgErro').html(htmlMessage);
            $('#msgErro').fadeIn('slow');
            $('#msgErro').delay(3000).fadeOut('slow');
        }
        else {
            $window.navigator.notification.alert(
                $(htmlMessage).text(),
                null,
                'ERRO!',
                'OK');
        }
    };

    this.ShowAlert = function (data) {
        if (date!=null) {
            if (typeof data === 'string') {
                this.ShowSucesso();
                $window.setTimeout(function () {
                    $state.go(data);
                }, 1500);
            }
            else if (data.status != 500 && data.data.Message != null) {
                this.ShowAviso(data.data.Message);
            }
            else {
                var message = data.statusText + '<br/>';
                if (data.data.ExceptionMessage != null) {
                    message += data.data.ExceptionMessage;
                }
                if (data.data.InnerException != null) {
                    message += data.data.InnerException.ExceptionMessage;
                }
                this.ShowErro(message);
            }
        }
        else {
            var message = data.statusText;
            this.ShowErro(message);
        }
    };
});