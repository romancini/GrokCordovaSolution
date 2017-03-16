App.filter('dateDiff', function () {
    var magicNumber = (1000 * 60 * 60 * 24);
    return function (toDate, fromDate) {
        if (toDate && fromDate) {
            var to = new Date(toDate).getTime();
            var from = new Date(fromDate).getTime();
            var dayDiff = Math.ceil((to - from) / magicNumber);
            if (angular.isNumber(dayDiff)) {
                return dayDiff > 0 ? dayDiff : 0;
            }
        }
    };
});