App.directive('iedecimal', function () {
    return {
        restrict: 'A',
        link: function (scope, element) {
            element.on('keydown', function (e) {
                // for internet explorer
                if (e.char!=null) {
                    var pattern = /^\d+$/;
                    if (!pattern.test(e.key)) {
                        if (e.keyCode !== 8) {
                            if (this.value.indexOf('.') == -1 && (e.keyCode===188 || e.keyCode===190)) {
                                this.value += '.';
                            }
                            else {
                                e.preventDefault();
                            }
                        }
                    }
                }
            });
        }
    };
});