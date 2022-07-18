# dotnet-helper-files

## Prerequisites

- **Visual Studio **: 2017 or higher
- **.NET Framework **: 4.6.1 or higher

## Clone and build dotnet helpers solution to create .dll

- Clone the project repository: git clone https://github.com/1Kosmos/dotnet-helper-files.git
- Open the project solution in visual studio 2017 or higher (double click on ecdsaHelper.sln file).
- Build the solution, by clicking on project -> right click -> Build.
- After successful build, dll named ecdsaHelper.dll will be generated on location: ecdsaHelper -> bin -> Debug.

## Add dotnet helpers .dll reference into your project

- In your project directory, copy and paste "ecdsaHelper.dll" file into your desired location.
- Add reference, Go into solution explorer, right click on "References" -> Add Reference -> Browse (select the "ecdsaHelper.dll" file pasted on above location).
- After successfully adding the reference, it will be visible under the "References" inside the solution explorer.

## How to use dotnet helpers into your project

Add namespace on the top of the your page:

```
using ecdsaHelper;

```

## To generate public and private key pair

Copy and past below line:

```
 var keyPair = BIDECDSA.GenerateKeyPair();

```

## To create shared key from public and private key pair

Copy and past below line:

```
 var sharedKey = BIDECDSA.CreateSharedKey(keyPair[0], keyPair[1]);

```

## To encrypt the string using the shared key

Copy and past below line:

```
 var encrypted = BIDECDSA.Encrypt("any string", sharedKey);

```

## To decrypt the string using the shared key

Copy and past below line:

```
var decrypt = BIDECDSA.Decrypt(encrypted, sharedKey);

```
