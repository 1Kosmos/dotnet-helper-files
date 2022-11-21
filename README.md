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
BIDTenantInfo bidTenantInfo = new BIDTenantInfo("<dns>", "<communityName>", "<licenseKey>");
BIDCommunityInfo communityInfo = BIDTenant.GetCommunityInfo(bidTenantInfo);

```

- To get SD (Service Directory) Information
Copy and past below line:

```
BIDTenantInfo bidTenantInfo = new BIDTenantInfo("<dns>", "<communityName>", "<licenseKey>");
BIDSD sd = BIDTenant.GetSD(bidTenantInfo);

```

## To Create OR Poll UWL2.0 session

Add namespace on the top of the your page:

```
using BIDHelpers.BIDSessions;
using BIDHelpers.BIDSessions.Model;

```
- To create new UWL2.0 session 
Copy and past below line:

```
BIDTenantInfo bidTenantInfo = new BIDTenantInfo("<dns>", "<communityName>", "<licenseKey>");
BIDSession sessionResponse = BIDSessions.CreateNewSession(bidTenantInfo, null, null);

```

- To poll new UWL2.0 session 
Copy and past below line:

```
BIDTenantInfo bidTenantInfo = new BIDTenantInfo("<dns>", "<communityName>", "<licenseKey>");
BIDSessionResponse pollResponse = BIDSessions.PollSession(bidTenantInfo, "sessionResponse.sessionId", true, true);

```

## To Request Email Verification link and Verify / Redeem Email verification link

Add namespace on the top of the your page:

```
using BIDHelpers.BIDAccessCodes;
using BIDHelpers.BIDTenant.Model;

```
- To Request Email Verification link
Copy and past below line:

```
BIDTenantInfo bidTenantInfo = new BIDTenantInfo("<dns>", "<communityName>", "<licenseKey>");
var requestEmailVerificationResponse  = BIDAccessCodes.RequestEmailVerificationLink(bidTenantInfo, "<emailTo>", "<emailTemplateB64OrNull>", "<emailSubjectOrNull>", "<createdBy>", "<ttl_seconds_or_null>");

```

- To poll new UWL2.0 session 
Copy and past below line:

```
BIDTenantInfo bidTenantInfo = new BIDTenantInfo("<dns>", "<communityName>", "<licenseKey>");
var fetchAccessCode = BIDAccessCodes.VerifyAndRedeemEmailVerificationCode(bidTenantInfo, requestEmailVerificationResponse.code);

```

## To Request/Verify OTP through email and/or sms

Add namespace on the top of the your page:

```
using BIDHelpers.BIDOTP;
using BIDHelpers.BIDOTP.Model;
using BIDHelpers.BIDTenant.Model;

```
- To Request OTP through email and/or sms
Copy and past below line:

```
BIDTenantInfo bidTenantInfo = new BIDTenantInfo("<dns>", "<communityName>", "<licenseKey>");
BIDOtpResponse requestOtp = BIDOTP.RequestOTP(bidTenantInfo, "<userName>", "<emailToOrNull>", "<smsToOrNull>", "<smsISDCodeOrNull>");

```

- To Verify OTP sent through email and/or sms 
Copy and past below line:

```
BIDTenantInfo bidTenantInfo = new BIDTenantInfo("<dns>", "<communityName>", "<licenseKey>");
BIDOtpVerifyResult verifyOTP = BIDOTP.VerifyOTP(bidTenantInfo, "<username>", "<otpCode>");

```


## To create/poll new Driver's License verification session

Add namespace on the top of the your page:

```
using BIDHelpers.BIDVerifyDocument;
using BIDHelpers.BIDVerifyDocument.Model;
using BIDHelpers.BIDMessaging;
using BIDHelpers.BIDMessaging.Model;
using BIDHelpers.BIDTenant.Model;

```
- To create new Driver's License verification session
Copy and past below line:

```
BIDTenantInfo bidTenantInfo = new BIDTenantInfo("<dns>", "<communityName>", "<licenseKey>");			
BIDCreateDocumentSessionResponse createdSessionResponse = BIDVerifyDocument.createDocumentSession(bidTenantInfo, "<dvcId>", "dl_object");

```

- To send SMS
```
BIDSendSMSResponse smsResponse = BIDMessaging.sendSMS(bidTenantInfo, "9463023515", "+91", smsTemplateB64);

```

- To poll new Driver's License response and verify the document
Copy and past below line:

```
BIDTenantInfo bidTenantInfo = new BIDTenantInfo("<dns>", "<communityName>", "<licenseKey>");			
BIDPollSessionResponse pollSessionResponse = BIDVerifyDocument.pollSessionResult(bidTenantInfo, "<dvcId>", "<sessionId>");

```

- To verify the document
```
BIDVerifyDocumentResponse documentResponse = BIDVerifyDocument.verifyDocument(bidTenantInfo, "<dvcId>", "<verifications>", "<faceCompareDocument>");

```