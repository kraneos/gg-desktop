var Parse = require('parse/node');
var fs = require('fs');

module.exports = function (serverUrl, appId, masterKey) {
    Parse.initialize(appId, null, masterKey);
    Parse.Cloud.useMasterKey();
    Parse.serverURL = serverUrl;

    return {
        createProvinces: createProvinces,
        createDistricts: createDistricts,
        createLocalities: createLocalities
    };
};

function createProvinces(jsonFile) {
    readFile(jsonFile, function (provinces) {
        var parseProvinces = provinces.map(function (p) {
            var parseProvince = new Parse.Object('Province');
            parseProvince.set('name', p.Name);
            var acl = new Parse.ACL();
            acl.setPublicReadAccess(true);
            acl.setPublicWriteAccess(false);
            parseProvince.setACL(acl);
            return parseProvince;
        });

        Parse.Object.saveAll(parseProvinces, {
            success: function (savedProvinces) {
                var newProvinces = [];
                savedProvinces.forEach(function (p, i) {
                    var prevProv = provinces[i];
                    newProvinces.push({
                        Id: prevProv.Id,
                        Name: prevProv.Name,
                        ObjectId: p.id,
                        CreatedAt: p.createdAt,
                        UpdatedAt: p.createdAt,
                        LocallyUpdatedAt: p.createdAt
                    });
                });
                writeFileAsNew(jsonFile, newProvinces);
            },
            error: console.log
        });
    });
}

function createLocalities(distFile, locFile) {
    var ParseDistrict = Parse.Object.extend('District');
    readFile(distFile, function (dists) {
        var locs = require('./data/localities');
        var parseLocs = locs.map(function (l) {
            var parseLoc = new Parse.Object('Locality');
            parseLoc.set('name', '' + l.Name);
            parseLoc.set('district', ParseDistrict.createWithoutData(dists.filter(function (d) {
                return d.Id === l.DistrictId;
            })[0].ObjectId));
            parseLoc.setACL(getPublicACL());
            console.log(parseLoc);
            return parseLoc;
        });
        Parse.Object.saveAll(parseLocs, {
            success: function (savedLocs) {
                var newLocs = [];
                savedLocs.forEach(function (l, i) {
                    var newLoc = locs[i];
                    newLoc.ObjectId = l.id;
                    newLoc.CreatedAt = l.createdAt;
                    newLoc.UpdatedAt = l.createdAt;
                    newLoc.LocallyUpdatedAt = l.createdAt;
                    console.log(newLoc);
                    newLocs.push(newLoc);
                });
                writeFileAsNew(locFile, newLocs);
            },
            error: console.log
        });
    });
}

function createDistricts(provFile, distFile) {
    var ParseProvince = Parse.Object.extend('Province');
    readFile(provFile, function (provs) {
        readFile(distFile, function (dists) {
            var parseDists = dists.map(function (d) {
                var parseDist = new Parse.Object('District');
                parseDist.set('name', '' + d.Name);
                parseDist.set('province', ParseProvince.createWithoutData(provs.filter(function (p) {
                    return p.Id === d.ProvinceId;
                })[0].ObjectId));
                parseDist.setACL(getPublicACL());
                return parseDist;
            });
            Parse.Object.saveAll(parseDists, {
                success: function (savedDists) {
                    var newDists = [];
                    savedDists.forEach(function (d, i) {
                        var newDist = dists[i];
                        newDist.ObjectId = d.id;
                        newDist.CreatedAt = d.createdAt;
                        newDist.UpdatedAt = d.createdAt;
                        newDist.LocallyUpdatedAt = d.createdAt;
                        newDists.push(newDist);
                    });
                    writeFileAsNew(distFile, newDists);
                },
                error: console.log
            });
        });
    });
}

function readFile(fileName, callback) {
    fs.readFile(fileName, 'utf8', function (err, data) {
        if (err) {
            throw err;
        }

        callback(JSON.parse(data));
    });
}

function writeFileAsNew(fileName, data) {
    var jsonIx = fileName.indexOf('.json');
    var newFileName = fileName.substring(0, jsonIx) + '.new.json';
    fs.writeFile(newFileName, JSON.stringify(data), function (err) {
        if (err) {
            throw err;
        }
        console.log('Save file to ' + newFileName);
    });
}

function getPublicACL() {
    var acl = new Parse.ACL();
    acl.setPublicReadAccess(true);
    acl.setPublicWriteAccess(false);
    return acl;
}