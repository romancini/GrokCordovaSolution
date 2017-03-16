App.config(function ($stateProvider, $httpProvider) {
    // Principal
    $stateProvider.state('principal', {
        url: '/',
        templateUrl: 'views/shared/form.html',
        controller: 'PrincipalController',
        modulo: 'principal'
    }).state('about', {
        url: '/about',
        templateUrl: 'views/Shared/about.html',
        controller: 'AboutController',
        modulo: 'principal'
    });

    // Instrumento
    $stateProvider.state('listInstrumentos', {
        url: '/Instrumento',
        templateUrl: 'views/CRUDS/Instrumento/List.html',
        controller: 'InstrumentoListController'
    }).state('newInstrumentos', {
        url: '/Instrumento/create',
        templateUrl: 'views/CRUDS/Instrumento/Create.html',
        controller: 'InstrumentoCreateController'
    }).state('editInstrumentos', {
        url: '/Instrumento/Edit/:Id',
        templateUrl: 'views/CRUDS/Instrumento/Edit.html',
        controller: 'InstrumentoEditController'
    }).state('viewInstrumentos', {
        url: '/Instrumento/:Id',
        templateUrl: 'views/CRUDS/Instrumento/Details.html',
        controller: 'InstrumentoDetailsController'
    });
});