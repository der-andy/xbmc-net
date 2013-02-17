# xbmc-net

A .NET library for the XBMC JSON RPC - currently in "experimental" state; just for my personal fun

It has only a few functions, but these do work... :-)

Requires .NET 4.5 because I'm using async stuff.

And since I'm writing this library mainly for me, it also targets the v6 API (Frodo). Older XBMC versions might not be supported.

### Usage example:

```csharp
using (var xbmc = new XbmcConnection("192.168.42.1", 9090))
{
    var movies = await xbmc.VideoLibrary.GetMovies();
    
    // or in non-async methods
    var movies = xbmc.VideoLibrary.GetMovies().Result;
}
```
