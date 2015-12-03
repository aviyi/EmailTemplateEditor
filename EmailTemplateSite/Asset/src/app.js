
var app = angular.module('app', ['ui.router', 'ui.tinymce', 'angucomplete']);

app.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/');

    $stateProvider
           .state('/home', {
               url: '/',
               templateUrl: 'homePage/home.tpl.html',
               controller: 'homeCtrl'
           })
    .state('/templateEditor', {
        url: '/templateEditor/:type/:id',
        templateUrl: 'templaeEditorPage/template-editor.tpl.html',
        controller: 'templateEditorCtrl'
    })


});