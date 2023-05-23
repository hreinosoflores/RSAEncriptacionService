# RSAEncriptacionService

Basic login  
POST  
http://localhost:42371/api/user/basic-login  
```
{
	"idUsuario": "hreinoso",
	"contrasenha": "123456"
}
```

RSA login  
POST  
http://localhost:42371/api/user/rsa-login
```
{
	"idUsuario": "oflores",
	"contrasenha": "IPYtQyJAqK65iyL0CPTpxIFL/sRIaX2WNaHUnpFYsTuGwWaTXG+tbkfTNNvMt4OYk2gm8cUIRSBuhoiiM9aUSMtLr4P4N5HNby0UvEQ8cNQa5av6aBQM8/Jb7Mch6/1MDUpTU/z+s4GkQUuhdrOB+BTMVg3D17spmOetrFvk4Es="
}
```

RSA login avanzado  
POST  
http://localhost:42371/api/user/rsa-advanced-login
```
{
	"data": "M1AxkxU47Y9LOI6Q1xdFATdyj3RhFQX/x0qCRMRgCkg/Uq+idbnw2l8Iykg400a74Iut9lBwbFV3s4bowCOd0AMXBmqIwyWpXwYsttU+imAEnorA1qp2ECPLn216EIwyPKdKogVWC5CEmsUPu3saijPom+gPAaTFj0OQZkQwk2I="
}
```
