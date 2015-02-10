'use strict';

describe('Controller: UnitydebuglogCtrl', function () {

  // load the controller's module
  beforeEach(module('unityDebugFrontendMonitorApp'));

  var UnitydebuglogCtrl,
    scope;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($controller, $rootScope) {
    scope = $rootScope.$new();
    UnitydebuglogCtrl = $controller('UnitydebuglogCtrl', {
      $scope: scope
    });
  }));

  it('should attach a list of awesomeThings to the scope', function () {
    expect(scope.awesomeThings.length).toBe(3);
  });
});
