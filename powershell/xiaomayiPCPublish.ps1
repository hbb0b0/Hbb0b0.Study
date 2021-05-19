#Invoke-Expression "path D:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin"
#Invoke-Expression "msbuid.exe E:\work\sup2\branch\sup-5516\sup-heart\SUP商户版\SUP_sof\SUP_sof.sln"
cmd.exe /c 'path D:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin'
cmd.exe /c 'C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe' /target:Clean /target:Build 'E:\work\sup2\branch\sup-5516\sup-heart\SUP商户版\SUP_sof\SUP_sof.sln'
 # Local Variables
    #$MsBuild = $env:systemroot + "\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe";

<#
function global:copy-bin($src, $dest, $buildType)
{
    pwd
    echo "xcopy `"$src\bin\$buildType\.`"  `"$dest\`" /e /y /d  /EXCLUDE:copyExcludeBin.txt"
    xcopy "$src\bin\$buildType\."  "$dest\" /e /y /d  /EXCLUDE:copyExcludeBin.txt
    pwd
}

function global:Build-VisualStudioSolution ($SolutionFilePath, $Configuration, $CleanFirst, $Platform )
{
    # Local Variables
    $MsBuild = $env:systemroot + "\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe";


    # Local Variables
    $fileinfo = ([System.IO.FileInfo]$SolutionFilePath) ;
    $SolutionFile = $fileinfo.Name;
    $BuildOutput = "BuildLogOutput.txt";
    $BuildLogFile=  $fileinfo.DirectoryName + "\msbuild.log"; # 这个名字是对应 /fl1
    $bOk = $true;
    write-host "SolutionFilePath : $SolutionFilePath";
    write-host "SolutionFile : $SolutionFile";
    write-host "BuildLog     : $BuildOutput";
    write-host "BuildLogFile : $BuildLogFile";

    try
    {

        # Clear first?
        if($CleanFirst)
        {
            write-host CleanFirst
            &$MsBuild $SolutionFilePath /t:clean /p:Configuration=$Configuration/v:minimal
        }

        write-host  "Building..." 
        $MsBuildArgs = "/p:Configuration=$Configuration"
        if ($Platform)
        {
            $Platform += ("/p:Platform="""+$Platform+"""") 
        }
        #/nologo

         &$MsBuild  $SolutionFilePath /t:build $Platform  $MsBuildArgs /verbosity:normal /clp:ShowEventId /flp:"Summary;Verbosity=normal;LogFile=$BuildLogFile"
        $ret = $?;
        echo "MsBuild 编译=$ret";
        if ($ret)
        {
            #echo "MsBuild 编译成功";
            $bOk = $true;
        }
        else
        {
            #echo "MsBuild 编译失败";
            $bOk = $false;
        }
    }
    catch
    {
        $bOk = $false;
        Write-Error ("Unexpect error occured while building " + $SolutionFile + ": " + $_.Exception.Message);
    }

    # All good so far?
    if($bOk)
    {
        #Show projects which where built in the solution
        #Select-String -Path $BuildOutput -Pattern "Done building project" -SimpleMatch

        # Show if build succeeded or failed...
        #echo $BuildLogFile;
        $successes = Select-String -Path $BuildLogFile -Pattern "已成功生成" -SimpleMatch -Encoding default
        $failures = Select-String -Path $BuildLogFile -Pattern "生成失败" -SimpleMatch -Encoding default

        if($failures -ne $null)
        {
            #Write-Warning ($SolutionFile + ": A build failure occured. Please check the build log $BuildOutput for details.");
        }
        #echo "successes = $successes" ;
        #echo "failures = $failures" ;

        if($successes  -and  !$failures )
        {
            $global:ret = "ok";
            return "ok";
        }
    }
}

#$ret = Build-VisualStudioSolution -SolutionFilePath "E:\src-temp\xxxxx" -Configuration "Debug" ;
#if ($ret = "ok")
#{
#    copy-bin    "E:\src-temp\ConsoleApplication1\ConsoleApplication1" "E:\src-temp\ConsoleApplication1\build\" "debug"
#}

 # 获取编译函数
 #不要忘了命令开始的点和中间的空格：“来自点后”的文件请确保它们全部的变量和函数有定义在被调用的脚本里面同时在脚本执行时不能删除它。
 #. "$PSScriptRoot\build_fun.ps1"
.\build_fun.ps1


$tf = "C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\tf.exe"
echo 切换TFS工作区
    # 加了登录信息会提示 指定的项过多的错误 /login:yx\yeab,"abc123" 
&$tf workspaces /collection:http://172.16.1.2:8080/DevelopmentCollection src_temp  

$tf_path="\$/Conv/Source/Branches/201708"
$local_path="F:\src-temp\Conv\road"
echo "开始更新 \$tf_path"
&$tf get $local_path   /force #/recursive

#客户端
$global:ret = 0
Build-VisualStudioSolution  "F:\src-temp\Conv\road\Foreground\Foreground.sln" "Debug" \$false 
if ($ret -eq "ok")
{
    xcopy   "F:\src-temp\Conv\road\Foreground\H2010Client\." "F:\src-temp\Conv_publish\02.Client\"  /e /y /d 
}
#服务器端
$global:ret = 0
Build-VisualStudioSolution  "F:\src-temp\Conv\road\Server\Server.sln" "Debug" \$false 
if ($ret -eq "ok")
{
    copy-bin    "F:\src-temp\Conv\road\Server" "F:\src-temp\publish\01.Server" 
}
#>

