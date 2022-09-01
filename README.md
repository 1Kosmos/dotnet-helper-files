# dotnet-helper-files

## Prerequisites

- **Visual Studio **: 2017 or higher
- **.NET Framework **: 4.6.1 or higher

## Clone and build dotnet helpers BIDHelpers solution to create .dll

- Clone the project repository: git clone https://github.com/1Kosmos/dotnet-helper-files.git
- Open the project solution in visual studio 2017 or higher (double click on BIDHelpers.sln file).
- Build the solution, by clicking on project -> right click -> Build.
- After successful build, dll named BIDHelpers.dll will be generated on location: BIDHelpers -> bin -> Debug.

## Add dotnet helpers BIDHelpers.dll reference into your project

- In your project directory, copy and paste "BIDHelpers.dll" file into your desired location.
- Add reference, Go into solution explorer, right click on "References" -> Add Reference -> Browse (select the "BIDHelpers.dll" file pasted on above location).
- After successfully adding the reference, it will be visible under the "References" inside the solution explorer.

## How to use dotnet helpers BIDHelpers.dll into your project

Add namespace on the top of the your page:

```
using BIDHelpers.BIDECDSA;

```

## To generate public and private key pair

Copy and past below line:

```
 var keyPair = BIDECDSA.GenerateKeyPair();

```

## To create shared key from public and private key pair

Copy and past below line:

```
 var sharedKey = BIDECDSA.CreateSharedKey(keyPair.prKey, keyPair.pKey);

```

## To encrypt the string using the shared key

Copy and past below line:

```
 var encryptedBase64String = BIDECDSA.Encrypt("any string", sharedKey);

```

## To decrypt the string using the shared key

Copy and past below line:

```
var decryptedPlainString = BIDECDSA.Decrypt(encryptedBase64String, sharedKey);

```

## To get community info and sd (Service Directory)

Add namespace on the top of the your page:

```
using BIDHelpers.BIDTenant;
using BIDHelpers.BIDTenant.Model;

```

- To get Community Information
Copy and past below line:

```
BIDTenantInfo bidTenantInfo = new BIDTenantInfo("dns", "communityName", "lecenseKey");
BIDCommunityInfo communityInfo = BIDTenant.getCommunityInfo(bidTenantInfo);

```

- To get SD (Service Directory) Information
Copy and past below line:

```
BIDTenantInfo bidTenantInfo = new BIDTenantInfo("dns", "communityName", "lecenseKey");
BIDSD sd = BIDTenant.getSD(bidTenantInfo);

```
