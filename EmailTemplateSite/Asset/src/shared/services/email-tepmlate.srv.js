app.service('emailTempalteService', ['$http', function ($http) {

    function AddForBranch(branchId, subject, body) {
        var data = {
            branchId: branchId,
            subject: subject,
            body: body
        }
        return $http.post('/api/EmailTemplate/AddedForBranch', data)
    }
    return {
        AddForBranch: AddForBranch
    }
}])