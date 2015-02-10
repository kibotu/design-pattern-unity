'use strict';

/**
 * @ngdoc overview
 * @name unityDebugFrontendMonitorApp
 * @description
 * # unityDebugFrontendMonitorApp
 *
 * Main module of the application.
 */
angular
  .module('unityDebugFrontendMonitorApp', [
    'ngAnimate',
    'ngCookies',
    'ngResource',
    'ngRoute',
    'ngSanitize',
    'ngTouch'
  ])
  .config(function ($routeProvider) {
    $routeProvider
      .when('/', {
        templateUrl: 'views/main.html',
        controller: 'MainCtrl'
      })
      .when('/about', {
        templateUrl: 'views/about.html',
        controller: 'AboutCtrl'
      })
      .when('/UnityDebugLog', {
        templateUrl: 'views/unitydebuglog.html',
        controller: 'UnitydebuglogCtrl'
      })
      .otherwise({
        redirectTo: '/'
      });
  });
