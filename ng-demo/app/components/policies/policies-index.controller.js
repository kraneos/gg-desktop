(function () {
  angular.module('app').controller('PoliciesIndexCtrl', PoliciesIndexCtrl);
  
  PoliciesIndexCtrl.$inject = ['PoliciesService', 'UtilityService'];
  
  function PoliciesIndexCtrl(PoliciesService, UtilityService) {
    var self = this;
    init(self);
    
    function init(self) {
      self.policies = [];
      
      fetchPolicies();
    }
    
    function fetchPolicies() {
      PoliciesService.query().$promise.then(onSucceded, UtilityService.onRequestError);
      
      function onSucceded(res) {
        self.policies = res.results;
      }
    }
  }
})();