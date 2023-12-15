û
iC:\CareerHuBT\WebApi\LiveSupport\LiveSupportServer\LiveSupportServer.WebApi\Abstractions\ApiController.cs
	namespace 	
LiveSupportServer
 
. 
WebApi "
." #
Abstractions# /
;/ 0
[ 
Route 
( 
$str "
)" #
]# $
[ 
ApiController 
] 
public 
abstract 
class 
ApiController #
:$ %
ControllerBase& 4
{ 
	protected		 
readonly		 
	IMediator		  
	_mediator		! *
;		* +
	protected 
ApiController 
( 
	IMediator %
mediator& .
). /
{ 
	_mediator 
= 
mediator 
; 
} 
} …
jC:\CareerHuBT\WebApi\LiveSupport\LiveSupportServer\LiveSupportServer.WebApi\Controllers\AdminController.cs
	namespace 	
LiveSupportServer
 
. 
WebApi "
." #
Controllers# .
;. /
public 
class 
AdminController 
: 
ApiController ,
{		 
public

 

AdminController

 
(

 
	IMediator

 $
mediator

% -
)

- .
:

/ 0
base

1 5
(

5 6
mediator

6 >
)

> ?
{ 
} 
[ 
HttpPost 
] 
public 

async 
Task 
< 
IActionResult #
># $
GetAllChatRoom% 3
(3 4
GetAllChatRoomQuery4 G
requestH O
,O P
CancellationTokenQ b
cancellationTokenc t
)t u
{ 
return 
Ok 
( 
await 
	_mediator !
.! "
Send" &
(& '
request' .
,. /
cancellationToken0 A
)A B
)B C
;C D
} 
[ 
HttpPost 
] 
public 

async 
Task 
< 
IActionResult #
># $
ConnectChatRoom% 4
(4 5"
ConnectChatRoomCommand5 K
requestL S
,S T
CancellationTokenU f
cancellationTokeng x
)x y
{ 
await 
	_mediator 
. 
Send 
( 
request $
,$ %
cancellationToken& 7
)7 8
;8 9
return 
	NoContent 
( 
) 
; 
} 
} Š
iC:\CareerHuBT\WebApi\LiveSupport\LiveSupportServer\LiveSupportServer.WebApi\Controllers\AuthController.cs
	namespace 	
LiveSupportServer
 
. 
WebApi "
." #
Controllers# .
;. /
public 
class 
AuthController 
: 
ApiController +
{		 
public

 

AuthController

 
(

 
	IMediator

 #
mediator

$ ,
)

, -
:

- .
base

/ 3
(

3 4
mediator

4 <
)

< =
{ 
} 
[ 
HttpPost 
] 
public 

async 
Task 
< 
IActionResult #
># $
Register% -
(- .
RegisterCommand. =
request> E
,E F
CancellationTokenG X
cancellationTokenY j
)j k
{ 
await 
	_mediator 
. 
Send 
( 
request $
,$ %
cancellationToken& 7
)7 8
;8 9
return 
	NoContent 
( 
) 
; 
} 
[ 
HttpPost 
] 
public 

async 
Task 
< 
IActionResult #
># $
Login% *
(* +
LoginCommand+ 7
request8 ?
,? @
CancellationTokenA R
cancellationTokenS d
)d e
{ 
var 

token 
= 
await 
	_mediator "
." #
Send# '
(' (
request( /
,/ 0
cancellationToken1 B
)B C
;C D
return 
Ok 
( 
new 
{ 
Token 
= 
token  %
}& '
)' (
;( )
} 
} ½
nC:\CareerHuBT\WebApi\LiveSupport\LiveSupportServer\LiveSupportServer.WebApi\Controllers\ChatRoomsController.cs
	namespace 	
LiveSupportServer
 
. 
WebApi "
." #
Controllers# .
;. /
public

 
class

 
ChatRoomsController

  
:

! "
ApiController

# 0
{ 
public 

ChatRoomsController 
( 
	IMediator (
mediator) 1
)1 2
:3 4
base5 9
(9 :
mediator: B
)B C
{ 
} 
[ 
HttpPost 
] 
public 

async 
Task 
< 
IActionResult #
># $
CreateChatRoom% 3
(3 4!
CreateChatRoomCommand4 I
requestJ Q
,Q R
CancellationTokenS d
cancellationTokene v
)v w
{ 
string 
id 
= 
await 
	_mediator #
.# $
Send$ (
(( )
request) 0
,0 1
cancellationToken2 C
)C D
;D E
return 
Ok 
( 
new 
{ 

ChatRoomId "
=# $
id% '
}( )
)) *
;* +
} 
[ 
HttpPost 
] 
public 

async 
Task 
< 
IActionResult #
># $(
GetAllChatRoomDetailByChatId% A
(A B1
%GetAllChatRoomDetailByChatRoomIdQueryB g
requesth o
,o p
CancellationToken	q ‚
cancellationToken
ƒ ”
)
” •
{ 
var 
response 
= 
await 
	_mediator &
.& '
Send' +
(+ ,
request, 3
,3 4
cancellationToken5 F
)F G
;G H
return 
Ok 
( 
response 
) 
; 
} 
[ 
HttpPost 
] 
public 

async 
Task 
< 
IActionResult #
># $
CreateANewMessage% 6
(6 7$
CreateANewMessageCommand7 O
requestP W
,W X
CancellationTokenY j
cancellationTokenk |
)| }
{   
await!! 
	_mediator!! 
.!! 
Send!! 
(!! 
request!! $
,!!$ %
cancellationToken!!& 7
)!!7 8
;!!8 9
return"" 
	NoContent"" 
("" 
)"" 
;"" 
}## 
}$$ ¹
VC:\CareerHuBT\WebApi\LiveSupport\LiveSupportServer\LiveSupportServer.WebApi\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. 
AddCors 
( 
cfr 
=> 
{ 
cfr		 
.

 	
AddDefaultPolicy

	 
(

 
policy

  
=>

! #
policy 
. 
AllowAnyMethod 
( 
) 
. 
AllowAnyHeader 
( 
) 
. 
AllowCredentials 
( 
) 
. 
SetIsOriginAllowed 
(  
policy  &
=>' )
true* .
). /
)/ 0
;0 1
} 
) 
; 
builder 
. 
Services 
. 
AddApplication 
(  
)  !
;! "
builder 
. 
Services 
. 
AddInfrasturcture "
(" #
builder# *
.* +
Configuration+ 8
)8 9
;9 :
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder 
. 
Services 
. #
AddEndpointsApiExplorer (
(( )
)) *
;* +
builder 
. 
Services 
. 
AddSwaggerGen 
( 
)  
;  !
var 
app 
= 	
builder
 
. 
Build 
( 
) 
; 
if 
( 
app 
. 
Environment 
. 
IsDevelopment !
(! "
)" #
)# $
{ 
app 
. 

UseSwagger 
( 
) 
; 
app 
. 
UseSwaggerUI 
( 
) 
; 
} 
app!! 
.!! 
UseCors!! 
(!! 
)!! 
;!! 
app## 
.## 
UseHttpsRedirection## 
(## 
)## 
;## 
app%% 
.%% 
UseAuthorization%% 
(%% 
)%% 
;%% 
app'' 
.'' 
MapControllers'' 
('' 
)'' 
;'' 
app)) 
.)) 
MapHub)) 

<))
 
CreateRoomHub)) 
>)) 
()) 
$str)) ,
))), -
;))- .
app++ 
.++ 
Run++ 
(++ 
)++ 	
;++	 
