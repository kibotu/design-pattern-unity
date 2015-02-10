'use strict';

/**
 * @ngdoc function
 * @name unityDebugFrontendMonitorApp.controller:UnitydebuglogCtrl
 * @description
 * # UnitydebuglogCtrl
 * Controller of the unityDebugFrontendMonitorApp
 */
angular.module('unityDebugFrontendMonitorApp')
  .controller('UnitydebuglogCtrl', function ($scope, $http, $sce, $interval) {
    $scope.logs = [];

    function refreshLogs() {
      $http.get('http://localhost:3000/api/UnityDebugLogModels?access_token=token').
        success(function (data) {
          data.forEach(function (logEntry) {
            logEntry.text = $sce.trustAsHtml(logEntry.text);
          });
          $scope.logs = data;
          $interval(refreshLogs, 2000, 1);
        });
    }

    refreshLogs();

  });
