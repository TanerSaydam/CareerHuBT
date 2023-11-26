```

BenchmarkDotNet v0.13.10, Windows 11 (10.0.22621.2715/22H2/2022Update/SunValley2)
AMD Ryzen 5 3600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


```
| Method      | Mean     | Error    | StdDev   | Ratio | RatioSD |
|------------ |---------:|---------:|---------:|------:|--------:|
| ToListAsync | 12.23 ms | 0.211 ms | 0.187 ms |  1.00 |    0.00 |
| AsQueryable | 11.74 ms | 0.226 ms | 0.232 ms |  0.96 |    0.02 |
