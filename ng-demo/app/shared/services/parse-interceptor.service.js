(function () {
  angular.module('app').factory('ParseInterceptorService', ParseInterceptorService);

  ParseInterceptorService.$inject = ['$q', 'parseKeys'];

  function ParseInterceptorService($q, parseKeys) {
    var svc = {
      request: request,
      responseError: responseError
    };

    return svc;

    function request(config) {
      if (config.url.indexOf('http') === -1 && config.url.indexOf('classes') === 0 && config.url.indexOf('/') !== 0) {
        config.url = parseKeys.baseUrl + config.url;
      }
      config.headers = config.headers || {};
      config.headers['X-Parse-Application-Id'] = parseKeys.applicationId;
      config.headers['X-Parse-REST-API-Key'] = parseKeys.restApiKey;
      return config
    }

    function responseError(rejection) {

    }
  }
})();