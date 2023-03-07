# dotnet-helper-files

## Prerequisites

- **Visual Studio **: 2017 or higher
- **.NET Framework **: 4.6.1 or higher

## Clone and build dotnet helpers BIDHelpers solution to create .dll

- Clone the project repository: git clone https://github.com/1Kosmos/dotnet-helper-files.git

	a) Clone the main repository git clone https://github.com/1Kosmos/dotnet-helper-files.git. Clone of main repository will not pull the submodules. You need to execute step 'b' and 'c' as well.

	```shell 
	git clone https://github.com/1Kosmos/dotnet-helper-files.git
	```

	b) To initialize a Git submodule, use the “git submodule update” command with the “–init” and the “–recursive” options. This command will register the git submodule directory path for 'shared' folder.

    ```shell 
	git submodule update --init --recursive
	```

	c) In order to update an existing Git submodule, you need to execute the “git submodule update” with the “–remote” and the “–merge” option.

	```shell 
    git submodule update --remote --merge
	```
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
BIDCreateDocumentSessionResponse createdSessionResponse = BIDVerifyDocument.CreateDocumentSession(bidTenantInfo, "<dvcId>", "dl_object");

```

- Trigger SMS
```
BIDSendSMSResponse smsResponse = BIDMessaging.SendSMS(bidTenantInfo, "<smsTo>", "<smsISDCode>", "<smsTemplateB64>");

```

- To poll new Driver's License response and verify the document
Copy and past below line:

```
BIDTenantInfo bidTenantInfo = new BIDTenantInfo("<dns>", "<communityName>", "<licenseKey>");			
BIDPollSessionResponse pollSessionResponse = BIDVerifyDocument.PollSessionResult(bidTenantInfo, "<dvcId>", "<sessionId>");

```

- To verify the document
```
BIDVerifyDocumentResponse documentResponse = BIDVerifyDocument.VerifyDocument(bidTenantInfo, "<dvcId>", "<verifications>", "<faceCompareDocument>");

```


## To Register and Authenticate using FIDO2

Add namespace on the top of the your page:

```
using BIDHelpers.BIDWebAuthn;
using BIDHelpers.BIDWebAuthn.Model;
using BIDHelpers.BIDTenant.Model;

```
- To FetchAttestationOptions for register
Copy and past below line:

```
BIDTenantInfo bidTenantInfo = new BIDTenantInfo("<dns>", "<communityName>", "<licenseKey>");	
		
//If your device is a security key, such as a YubiKey
var bidAttestationValues = new BIDAttestationOptionsValue()
    {
		displayName = "<displayName>",
        username = "<username>",
        dns = "<dns>",
        attestation = "direct",
        authenticatorSelection = new BIDAuthenticatorSelectionValue()
        {
           requireResidentKey = true
        },
    };

//If your device is a platform authenticator, such as TouchID:
var bidAttestationValues = new BIDAttestationOptionsValue()
	{
		ddisplayName = "<displayName>",
		username = "<username>",
		dns = "<dns>",
		attestation = "direct",
		authenticatorSelection = new BIDAuthenticatorSelectionValue()
		{
			authenticatorAttachment = "platform"
		},
	};
	
//If your device is a MacBook:
var bidAttestationValues = new BIDAttestationOptionsValue()
	{
		displayName = "<displayName>",
		username = "<username>",
		dns = "<dns>",
		attestation = "none",
	};

BIDAttestationOptionsResponse attestationOptionsResponse = BIDWebAuthn.FetchAttestationOptions(bidTenantInfo, "<bidAttestationValues>");

```


- To SubmitAttestationResult for registeration
Copy and past below line:

```
BIDTenantInfo bidTenantInfo = new BIDTenantInfo("<dns>", "<communityName>", "<licenseKey>");
BIDAttestationResultValue attestationResultRequest = new BIDAttestationResultValue
            {
                rawId = "<rawId>",
                response = new BIDAttestationResultResponseValue() { 
                attestationObject = "<attestationObject>",
                clientDataJSON = "<clientDataJSON>",
                getAuthenticatorData = {},
                getPublicKey = {},
                getPublicKeyAlgorithm = {},
                getTransports = {},
                },
                authenticatorAttachment = "<authenticatorAttachment>",
                getClientExtensionResults = "<getClientExtensionResults>",
                id = "<id>",
                type = "<type>",
                dns = "<current domain>"
            };
BIDAttestationResultData attestationResultResponse = BIDWebAuthn.SubmitAttestationResult(bidTenantInfo, "<attestationResultRequest>");

```

- To FetchAssertionOptions for authenticate
Copy and past below line:

```
BIDTenantInfo bidTenantInfo = new BIDTenantInfo("<dns>", "<communityName>", "<licenseKey>");	
		
BIDAssertionOptionValue assertionOptionRequest = new BIDAssertionOptionValue
            {
                username = "<username>",
                displayName = "<displayName>",
                dns = "<current domain>"
            };
BIDAssertionOptionResponse assertionOptionResponse = BIDWebAuthn.FetchAssertionOptions(bidTenantInfo, assertionOptionRequest);

```


- To SubmitAssertionResult for authenticate
Copy and past below line:

```
BIDTenantInfo bidTenantInfo = new BIDTenantInfo("<dns>", "<communityName>", "<licenseKey>");
BIDAssertionResultValue assertionResultRequest = new BIDAssertionResultValue
            {
                rawId = "<rawId>",
                dns = "<dns>",
                response = new BIDAssertionResultResponseValue()
                {
                    authenticatorData = "<authenticatorData>",
                    signature = "<signature>",
                    userHandle = "<userHandle>",
                    clientDataJSON = "<clientDataJSON>",
                },
                getClientExtensionResults = "<getClientExtensionResults>",
                id = "<id>",
                type = "<type>"
            };

BIDAssertionResultResponse assertionResultResponse = BIDWebAuthn.SubmitAssertionResult(bidTenantInfo, assertionResultRequest);


```