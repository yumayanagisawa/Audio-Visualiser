const{ ElvClient }= require ("elv-client-js/src/ElvClient");
var urljoin = require ("url-join");
var fs = require('fs');

var add = async function asyncCall() {
const client = ElvClient.FromConfiguration({ "configuration": 
    {
        "fabric": {
          "contentSpaceId": "ispc3J1jEWCr6mhHv6jhYuoVYotPxAy4",
          "hostname": "q.contentfabric.io",
          "port": 80,
          "use_https": false
        },
        "ethereum": {
          "hostname": "209.51.161.242",
          "port": 8545,
          "use_https": false
        }
      }
    })

    let wallet = client.GenerateWallet();
    let signer = wallet.AddAccount({
        privateKey: "0xe73b15e05270b088545ce265eb35371961ac24bc50808d0eee81dfe2f8b374f0"
    })
    client.SetSigner({signer});

    const Path = require("path");
    console.log(urljoin("qulibs", "ilib3uSGDLqp52GEnxcpHUeXpYpzrUsf"));

    try{
    const objectCreate = await client.CreateContentObject({
     
      "libraryId": "ilib3uSGDLqp52GEnxcpHUeXpYpzrUsf",
      "options": {
        "type": "hq__Qmd4E5wLQXGSYYbYuNsYVEYEtD1u6RmHtfiUA7mc1x1MUY",
        "meta": {
          "name" : process.argv[2],
          "toMerge": {
            "merge": "me"
          },
          "toReplace": {
            "replace": "me"
          },
          "toDelete": {
            "delete": "me"
          }
        }
      }
    });
    
    function getFilesizeInBytes(filename) {
      const stats = fs.statSync(filename)
      const fileSizeInBytes = stats.size
      return fileSizeInBytes
  }
    
    const uploadfile = await client.UploadPart({
      "libraryId": "ilib3uSGDLqp52GEnxcpHUeXpYpzrUsf",
      "objectId": objectCreate.id,
      "writeToken": objectCreate.write_token,
      "data": fs.readFileSync(process.argv[2])
      
    });

    await client.MergeMetadata({
      "libraryId": "ilib3uSGDLqp52GEnxcpHUeXpYpzrUsf",
      "objectId": objectCreate.id,
      "writeToken": objectCreate.write_token,
      "metadata":{"video":uploadfile.part.hash},

    })
    await client.FinalizeContentObject({
      "libraryId": "ilib3uSGDLqp52GEnxcpHUeXpYpzrUsf",
      "objectId": objectCreate.id,
      "writeToken": objectCreate.write_token
    });} catch(error){ console.log(error)};}
add();

    // client.ContentLibraries().then(libraries => console.log(libraries)).catch(error => console.log(error))

    // client.ContentLibrary({libraryId: "ilib2AWdn731Mrrn68nmyP8WMqUpx69M"}).then(libraries => console.log(libraries)).catch(error => console.log(error))