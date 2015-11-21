 
var app = angular.module('app', ['ui.router', 'ui.tinymce']);

app.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/');

    $stateProvider
           .state('/home', {
               url: '/',
               templateUrl: 'homePage/home.tpl.html',
               controller: 'homeCtrl'
           })
    .state('/templateEditor', {
        url: '/templateEditor/:type',
        templateUrl: 'templaeEditorPage/template-editor-page.tpl.html',
        controller: 'templateEditorPageCtrl'
    })

    
});