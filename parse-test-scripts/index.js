var Parse = require('parse/node');

Parse.initialize('seggu-api', null, 'SegguMasterKey');
// Parse.Cloud.useMasterKey();
Parse.serverURL = 'http://seggu-api-test.herokuapp.com/parse/';
// createNewSegguClientWithDefaults('Segurolandia');
module.exports = {
    queryAndDestroyAllClasses: queryAndDestroyAllClasses,
    createRole: createRole,
    fetchUsers: fetchUsers,
    createUser: createUser,
    destroyUser: destroyUser,
    createNewSegguClient: createNewSegguClient,
    getRoleUsers: getRoleUsers,
    getProvinceNullDistricts: getProvinceNullDistricts,
    createNewSegguClientWithDefaults: createNewSegguClientWithDefaults,
    logInAs: logInAs
};
//fetchUsers();
// queryAndDestroyAllClasses();
// createNewSegguClient('Seggurolandia', [
// {
//     username: 'egentile', password: 'seggu2016', email: 'egentilemontes@gmail.com'
// },
// {
//     username: 'ecolombano', password: 'seggu2016', email: 'colombanoemiliano@gmail.com'
// },
// {
//     username: 'fcaironi', password: 'seggu2016', email: 'fcaironi@gmail.com'
// },
// {
//     username: 'apolo', password: 'seggu2016', email: 'poloagustin@gmail.com'
// }]);

// getRoleUsers('PYcD7T2kW9');
// Parse.User.logIn('apolo', 'seggu2016').then(function (user) {
//     new Parse.Query(Parse.Role).get('PYcD7T2kW9').then(function (role) {
//         role.getUsers().add(user);
//         role.save().then(console.log);
//     })
// })

function createRole(name, segguClient) {
    var role = new Parse.Role();
    role.set('name', name);
    role.set('segguClient', segguClient);

    role.save();
}

function fetchUsers() {
    new Parse.Query(Parse.User).find(function (users) {
        users.forEach(function (user) {
            console.log(user.getUsername());
        });
    });
}

function createUser(username, password, email) {
    var user = new Parse.User();
    user.set('username', username);
    user.set('password', password);
    user.set("email", email);

    user.signUp(null, {
        success: function (user) {
            console.log('The user has been created.');
        },
        error: function (user, error) {
            // Show the error message somewhere and let the user try again.
            alert("Error: " + error.code + " " + error.message);
        }
    });
}

function queryAndDestroyAllClasses() {
    [
            'AccessoryType',
            'Asset',
            'Bank',
            'Bodywork',
            'Brand',
            'CasualtyType',
            'Client',
            'Company',
            'CreditCard',
            'LedgerAccount',
            'Producer',
            'Province',
            'Use',
            'VehicleType',
            'Cheque',
            'Contact',
            'Liquidation',
            'District',
            'Locality',
            'Risk',
            'VehicleModel',
            'Policy',
            'Endorse',
            'Employee',
            'FeeSelection',
            'Fee',
            'Vehicle',
            'Accessory',
            'Integral',
            'Address',
            'CashAccount',
    ].forEach(function (value) {
        queryAndDestroy(value);
    });

    function queryAndDestroy(className) {
        new Parse.Query(className).find(function (objects) {
            console.log("I'm gonna destroy " + objects.length + " objects in " + className);
            Parse.Object.destroyAll(objects).then(null, console.log);
            if (objects.length > 0) {
                queryAndDestroy(className);
            }
        }, console.log);
    }
}

function destroyUser(username, password) {
    Parse.User.logIn(username, password).then(function (user) {
        user.destroy().then(console.log, console.log);
    });
}

function createNewSegguClient(clientName, users) {
    var segguClient = new Parse.Object('SegguClient');
    segguClient.set('name', clientName);

    segguClient.save().then(function (savedClient) {
        var clientRole = getNewRole(savedClient.id);
        var clientClientsRole = getNewRole(savedClient.id + 'Clients');
        var roles = [clientRole, clientClientsRole];
        Parse.Object.saveAll(roles).then(function (savedRoles) {
            var parseUsers = users.map(function (user) {
                var parseUser = new Parse.User();
                parseUser.set('username', user.username);
                parseUser.set('password', user.password);
                parseUser.set('email', user.email);
                parseUser.set('segguClient', savedClient);
                return parseUser;
            });

            parseUsers.forEach(function (parseUser) {
                parseUser.signUp().then(function (createdUser) {
                    savedRoles[0].getUsers().add(createdUser);
                    savedRoles.save().then(console.log, console.log);
                }, console.log);
            })
        }, console.log);

        function getNewRole(roleName, segguClient) {
            var roleACL = new Parse.ACL();
            roleACL.setPublicReadAccess(true);
            var role = new Parse.Role(roleName, roleACL);
            return role;
        }
    }, console.log)
}

function createNewSegguClientWithDefaults(clientName) {
    var segguClient = new Parse.Object('SegguClient');
    segguClient.set('name', clientName);

    var users = [
{
    username: 'egentile' + clientName, password: 'seggu2016', email: 'egentilemontes@gmail.com'
},
{
    username: 'ecolombano' + clientName, password: 'seggu2016', email: 'colombanoemiliano@gmail.com'
},
{
    username: 'fcaironi' + clientName, password: 'seggu2016', email: 'fcaironi@gmail.com'
},
{
    username: 'apolo' + clientName, password: 'seggu2016', email: 'poloagustin@gmail.com'
}];

    segguClient.save().then(function (savedClient) {
        var clientRole = getNewRole(savedClient.id);
        var clientClientsRole = getNewRole(savedClient.id + 'Clients');
        var roles = [clientRole, clientClientsRole];
        Parse.Object.saveAll(roles).then(function (savedRoles) {
            var parseUsers = users.map(function (user) {
                var parseUser = new Parse.User();
                parseUser.set('username', user.username);
                parseUser.set('password', user.password);
                parseUser.set('email', user.email);
                parseUser.set('segguClient', savedClient);
                return parseUser;
            });

            parseUsers.forEach(function (parseUser) {
                parseUser.signUp().then(function (createdUser) {
                    savedRoles[0].getUsers().add(createdUser);
                    savedRoles.save().then(console.log, console.log);
                }, console.log);
            })
        }, console.log);

        function getNewRole(roleName, segguClient) {
            var roleACL = new Parse.ACL();
            roleACL.setPublicReadAccess(true);
            var role = new Parse.Role(roleName, roleACL);
            return role;
        }
    }, console.log)
}

function getRoleUsers(roleId) {
    new Parse.Query(Parse.Role).get(roleId).then(function (role) {
        role.getUsers().query().find().then(console.log, console.log);
        // new Parse.Query(Parse.User).equalTo('roles', role).find(console.log, console.log);
    }, console.log);
}

function getProvinceNullDistricts() {
    new Parse.Query('District').doesNotExist('province').find().then(console.log,console.log);
}

function logInAs(username, password) {
    Parse.User.logIn(username, password).then(console.log, console.log);
}