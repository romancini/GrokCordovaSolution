App.run(function ($state, $templateCache, $q, $rootScope, $location) {
    File.prototype.convertToBase64 = function (callback) {
        var reader = new FileReader();
        reader.onload = function (e) {
            callback(e.target.result);
        };
        reader.onerror = function (e) {
            callback(null);
        };
        reader.readAsDataURL(this);
    };

    Date.prototype.addHours = function (h) {
        this.setHours(this.getHours() + h);
        return this;
    };

    if (!String.prototype.startsWith) {
        String.prototype.startsWith = function (searchString, position) {
            position = position || 0;
            return this.indexOf(searchString, position) === position;
        };
    };

    $templateCache.removeAll();
    $state.go('principal');
    $('[data-toggle="tooltip"]').tooltip();
});