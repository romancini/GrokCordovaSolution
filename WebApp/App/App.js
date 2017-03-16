var App = angular.module('GrokCordovaApp', ['ui.router', 'ngResource', 'ngMessages', 'ngTouch', 'GrokCordovaApp.controllers', 'GrokCordovaApp.services'])
App.Services = angular.module('GrokCordovaApp.services', []);
App.Controllers = angular.module('GrokCordovaApp.controllers', []);

var serviceBase = 'http://localhost:8206/';