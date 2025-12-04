# 1. 建置階段 (使用 SDK Image 編譯程式碼)
# 注意：這裡使用 10.0 SDK
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# 先複製 csproj 並還原套件 (利用 Docker 快取機制加速)
COPY ["*.csproj", "./"]
RUN dotnet restore

# 複製其餘程式碼並進行發布
COPY . .
RUN dotnet publish -c Release -o /app/publish

# 2. 執行階段 (使用輕量級 Runtime Image 執行)
# 注意：這裡使用 10.0 ASP.NET Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .

# 設定監聽 Port (選用，但明確寫出來比較清楚)
ENV ASPNETCORE_HTTP_PORTS=8080

# ★★★ 請將 MyMvcApp.dll 改成您專案真正的 dll 名稱 ★★★
ENTRYPOINT ["dotnet", "WebApplication1.dll"]