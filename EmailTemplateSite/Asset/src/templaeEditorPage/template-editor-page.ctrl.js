app.controller('templateEditorPageCtrl', ['$scope', '$stateParams', 'emailTempalteService', function ($scope, $stateParams, emailTempalteService) {

    $scope.model = {};
    init();
    function init() {
        $scope.model.type = $stateParams.type;

    }
    $scope.save = function () {
        addTemplateForBranch();
    }

    function addTemplateForBranch() {
        emailTempalteService.AddForBranch(1, $scope.model.subject, $scope.model.body).then(function (response) {

            if (response.data == 'true') {
                alert('added')
            }
        })
    }


}])