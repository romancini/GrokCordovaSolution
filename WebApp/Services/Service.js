App.Services.factory('Instrumento', function ($resource) {
    return $resource(
        serviceBase + 'api/instrumento/:Id',
        {
            Id: '@Id'
        },
        {
            update: {
                method: 'PUT'
            }
        });
});

App.Services.factory('Values', function ($resource) {
    return $resource(
        serviceBase + 'api/values/:Id',
        {
            Id: '@Id'
        },
        {
            update: {
                method: 'PUT'
            }
        });
});