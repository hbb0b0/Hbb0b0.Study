$ftpUrlbase="ftp://121.36.11.249/lhb/ftptest/"
$ftpUserName="lhb"
$ftpPwd="lhb"
function Invoke-Environment() {
    param(
        [Parameter(Mandatory = 1)][string]$Command   # 待执行的脚本文件或命令
    )

    # 执行批处理脚本，最后调用set指令返回环境变量
    foreach ($_ in cmd /c " `"$Command`" > null 2>&1 && SET") {
        if ($_ -match '^([^=]+)=(.*)') {
            [System.Environment]::SetEnvironmentVariable($matches[1], $matches[2])
        }
    }
}

function Add-Directory {
    #定义函数参数
    param (
        [string] $RootDirName
    )

    #设置目录 Set-Location -Path C:\Windows -PassThru
    # System.DateTime| Get-Member -static 查看对象的方法
    Write-Output "current Dir:" $RootDirName
    #获取当前日期  
    $currentDir = [System.IO.Path]::Combine($RootDirName, [System.DateTime]::Now.ToString('yyyyMMdd'))
    #创建目录
    #判断目录是否存在
    if ([System.IO.Directory]::Exists( $currentDir)) {
        Write-Output '目录已存在'
        return 
    }
    [System.IO.Directory]::CreateDirectory($currentDir)
    #复制 文件到文件加
   
}

Function Invoke-FtpLogin {
    Param(
        [parameter(Mandatory = $true)]
        [string]$Site = "ftp://localhost",
        [string]$User = "Anonymous",
        [string]$Pass = "hello@world",
        [int]$Port = 21,
        [int]$TimeOut = 3000,
        [int]$ReadWriteTimeout = 10000
    )

    Write-Host "Get FTP site dir listing...开始"

    # Do directory listing
    $FTPreq = [System.Net.FtpWebRequest]::Create($Site)
    $FTPreq.Timeout = $TimeOut                          # msec (default is infinite)
    $FTPreq.ReadWriteTimeout = $ReadWriteTimeout        # msec (default is 300,000 - 5 mins)
    $FTPreq.KeepAlive = $false                          # (default is enabled)
    $FTPreq.Credentials = New-Object System.Net.NetworkCredential($User, $Pass)
    $FTPreq.Method = [System.Net.WebRequestMethods+FTP]::ListDirectory

    try {
        $FTPres = $FTPreq.GetResponse()
        $stream = New-Object System.Io.StreamReader($FTPres.getResponseStream(), [System.Text.Encoding]::Default)
        while (-not $stream.EndOfStream) {
            $stream.ReadLine()
        }
        $stream.Close()

        #Write-Host "$User _ $Pass OK"
        $success = $true

        #Write-Host $FTPres.StatusCode -nonewline
        #Write-Host $FTPres.StatusDescription
        $FTPres.Close()
    }
    catch {
        Write-Host "FAILED: $_"
        $success = $false
    }
}

Function Invoke-FtpCreateDir {
    Param(
        [parameter(Mandatory = $true)]
        [string]$Site = "ftp://localhost",
        [string]$User = "Anonymous",
        [string]$Pass = "hello@world",
        [int]$Port = 21,
        [int]$TimeOut = 3000,
        [int]$ReadWriteTimeout = 10000,
        [String]$DirName
    )

    Write-Host "Get FTP site dir listing...开始"

    # Do directory listing
    $FTPreq = [System.Net.FtpWebRequest]::Create($Site)
    $FTPreq.Timeout = $TimeOut                          # msec (default is infinite)
    $FTPreq.ReadWriteTimeout = $ReadWriteTimeout        # msec (default is 300,000 - 5 mins)
    $FTPreq.KeepAlive = $false                          # (default is enabled)
    $FTPreq.Credentials = New-Object System.Net.NetworkCredential($User, $Pass)
    $FTPreq.Method = [System.Net.WebRequestMethods+FTP]::MakeDirectory

    try {
        $FTPres = $FTPreq.GetResponse()
        $stream = New-Object System.Io.StreamReader($FTPres.getResponseStream(), [System.Text.Encoding]::Default)
        while (-not $stream.EndOfStream) {
            $stream.ReadLine()
        }
        $stream.Close()

        #Write-Host "$User _ $Pass OK"
        $success = $true

        #Write-Host $FTPres.StatusCode -nonewline
        #Write-Host $FTPres.StatusDescription
        $FTPres.Close()
    }
    catch {
        Write-Host "FAILED: $_"
        $success = $false
    }
}

function Get-FtpObject {
    Param(
        [parameter(Mandatory = $true)]
        [string]$Site = "ftp://localhost",
        [string]$User = "Anonymous",
        [string]$Pass = "hello@world"
             
    )

    #$Port = 21
    $TimeOut = 3000
    $ReadWriteTimeout = 10000
    Write-Host "开始初始化ftp object"

    # Do directory listing
    $FTPreq = [System.Net.FtpWebRequest]::Create($Site)
    $FTPreq.Timeout = $TimeOut                          # msec (default is infinite)
    $FTPreq.ReadWriteTimeout = $ReadWriteTimeout        # msec (default is 300,000 - 5 mins)
    $FTPreq.KeepAlive = $true                         # (default is enabled)
    $FTPreq.Credentials = New-Object System.Net.NetworkCredential($User, $Pass)
    $FTPreq.Method = [System.Net.WebRequestMethods+FTP]::ListDirectory

    try {
        $FTPres = $FTPreq.GetResponse()
        $stream = New-Object System.Io.StreamReader($FTPres.getResponseStream(), [System.Text.Encoding]::Default)
        while (-not $stream.EndOfStream) {
            $stream.ReadLine()
        }
        $stream.Close()

        Write-Host "ftp inialize $User _ $Pass OK"
    }
    catch {
        Write-Host "ftp inialize FAILED: $_"
    }
     
    Write-Host "初始化ftp完成"
    return $FTPreq
    
}

function FunctionName {
    param (
        [parameter(Mandatory = $true)]
        [String]$DirName
    )

    $url="ftp://121.36.11.249/lhb/ftptest/"
    $FTPreq=Get-FtpObject($url,"","")

    $FTPreq.Method= [System.Net.WebRequestMethods+FTP]::MakeDirectory

    
}



function Start-Build() {
    #定义函数参数
    param (
        [string] $SolutionPath,
        [string] $SiteClientSetupPath,
        [string] $SiteServerSetupPath
    )

    Write-Host  "SolutionPath：" $SolutionPath
    Write-Host  "SiteClientSetupPath：" $SiteClientSetupPath
    Write-Host  "SiteServerSetupPath：" $SiteServerSetupPath

    Invoke-Environment "C:\Program Files (x86)\Microsoft Visual Studio 9.0\VC\vcvarsall.bat"
   
    devenv  $SolutionPath /Rebuild Release   /project $SiteClientSetupPath /projectconfig Release  /project $SiteServerSetupPath /projectconfig Release
   
   
    Write-Host $MsBuild $SolutionPath
   
    $ret = $?;
    Write-Host "MsBuild 编译=$ret";
   

}



#Start-Build I:\Work\xiaomayi\svn20200809\小蚂蚁物流软件-WG6.1\SolutionALL\WGSolution\wgsolution.sln  WG.SiteClientSetupPath\WG.SiteClientSetupPath.vdproj WG.SiteServerSetup\WG.SiteServerSetup.vdproj


Invoke-FtpLogin -Site  ftp://121.36.11.249/lhb -User lhb -Pass lhb 