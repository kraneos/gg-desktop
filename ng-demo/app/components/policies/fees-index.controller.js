(function () {
  angular.module('app').controller('FeesIndexCtrl', FeesIndexCtrl);
  
  FeesIndexCtrl.$inject = ['FeesService', 'UtilityService', '$stateParams'];
  
  function FeesIndexCtrl(FeesService, UtilityService, $stateParams) {
    var self = this;
    init(self);
    
    function init(self) {
      self.fees = [];
      
      fetchFees();
    }
    
    function fetchFees() {
      FeesService.query({where: $stateParams}).$promise.then(onSucceded, UtilityService.onRequestError);
      
      function onSucceded(res) {
        self.fees = res.results;
      }
    }
  }
})();