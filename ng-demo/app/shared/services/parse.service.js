(function () {
  angular.module('app').factory('ParseService', ParseService);

  ParseService.$inject = ['$resource', 'parseKeys'];

  function ParseService($resource, parseKeys) {
    return {
      getParseService: getParseService
    };

    function getParseService(resource, params, extensionMethods) {
      for (var method in extensionMethods) {
        if (extensionMethods.hasOwnProperty(method)) {
          var extensionMethod = extensionMethods[method];
          extensionMethod.url = parseKeys.baseUrl + extensionMethod.url;
        }
      }

      resource.url = parseKeys.baseUrl + resource.url;
      return $resource(resource);
    }
  }
})();