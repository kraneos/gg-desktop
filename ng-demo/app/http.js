(function () {
    angular
        .module('app')
        .config([
            '$httpProvider',
            function ($httpProvider) {
                $httpProvider.interceptors.push('ParseInterceptorService');
            }]);
})();