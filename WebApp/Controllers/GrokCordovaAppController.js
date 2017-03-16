App.Controllers.controller('PrincipalController', function ($http, $scope, $state, myService, $window) {
    $($window.document).ready(function () {
        $(' .nav li a')
            .not('.dropdown-toggle')
            .on('click', function () {
                $('.navbar-ex1-collapse').removeClass('in').addClass('collapse');
        });
    });
}).controller('AboutController', function ($scope, $window) {
    $scope.recarregarApp = function () {
        $window.location.reload(true);
    };
});