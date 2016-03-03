(function () {
    angular.module('app').service('UtilityService', UtilityService);

    function UtilityService() {
        this.removeElementFromCollection = function (collection, element) {
            var i = collection.indexOf(element);
            collection.splice(i, 1);
        };
        this.onRequestError = function (error) {
            if (error.status === 403) {
                alert('You are not allowed to perform this operation.\nPlease, contact the system administrator.');
            } else if (error.status === 400) {
                if (error.data.modelState) {
                    angular.forEach(error.data.modelState, function (v) {
                        angular.forEach(v, alert);
                    });
                }
            } else if (error.data) {
                var msg = '';
                if (error.data.message) {
                    msg = error.data.message;
                }
                if (error.data.exceptionMessage) {
                    if (msg !== '') {
                        msg = msg + '\n';
                    }
                    msg = msg + error.data.exceptionMessage;
                }
                alert(msg);
            } else {
                alert('There was an error on the operation.\.Please, contact the system administrator.');
            }
        };
    }
})();