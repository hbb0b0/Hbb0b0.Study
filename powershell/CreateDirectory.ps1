function Add-Directory {
#定义函数参数
 param (
        [string] $RootDirName
    )

#设置目录 Set-Location -Path C:\Windows -PassThru
# System.DateTime| Get-Member -static 查看对象的方法
Write-Output "current Dir:" $RootDirName
 #获取当前日期  
 $currentDir=[System.IO.Path]::Combine($RootDirName,[System.DateTime]::Now.ToString('yyyyMMdd'))
 #创建目录
 #判断目录是否存在
 if([System.IO.Directory]::Exists( $currentDir))
 {
    Write-Output '目录已存在'
    return 
 }
  [System.IO.Directory]::CreateDirectory($currentDir)
 #复制 文件到文件加
   
}

function Start-Build()
{
   #定义函数参数
 param (
        [string] $SolutionPath
    )

    $MsBuild = $env:systemroot + "\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe";
  
    #$MsBuild =   "D:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild.exe";
    Write-Host  "msbuild所在目录：" $MsBuild
    #设置目录
    #Set-Location -Path "D:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools" -PassThru
   
    #&$MsBuild $SolutionPath /m  /t:publish /p:DeployOnBuild=true /p:Configuration=Debug /p:PublishDir=H:\xiaomayi\publish /p:platform=x86 /p:OutputPath=bin\Debug /p:TargetFrameworkVersion=v4.5
    &$MsBuild $SolutionPath /m  /t:rebuild /p:DeployOnBuild=false /p:Configuration=Debug /p:OutputPath=H:\xiaomayi\publish /p:platform="Any CPU" /p:OutputPath=bin\Debug /p:TargetFrameworkVersion=v4.5
    $ret=$?;
    echo "MsBuild 编译=$ret";

}

#Add-Directory -RootDirName H:\xiaomayi
#Start-Build E:\work\sup2\master2\sup-heart\SUP_heart\Build\SUP_heart.sln
#Start-Build E:\work\sup2\sup-hook\master\C#挂机\拼多多挂机\PingddPay\PingddPay.sln 

Start-Build E:\study\csharp\ADO.Solution\ADOConnectionPool\ADOConnectionPoolTestApp\ADOConnectionPoolTestApp.sln