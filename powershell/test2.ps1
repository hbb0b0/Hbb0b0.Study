function Invoke-Environment(){
    param(
        [Parameter(Mandatory=1)][string]$Command   # 待执行的脚本文件或命令
    )

    # 执行批处理脚本，最后调用set指令返回环境变量
    foreach($_ in cmd /c " `"$Command`" > null 2>&1 && SET") {
        if ($_ -match '^([^=]+)=(.*)') {
            [System.Environment]::SetEnvironmentVariable($matches[1], $matches[2])
        }
    }
}
Invoke-Environment "C:\Program Files (x86)\Microsoft Visual Studio 9.0\VC\vcvarsall.bat"

devenv "I:\Work\xiaomayi\svn20200809\小蚂蚁物流软件-WG6.1\SolutionALL\WGSolution\WGSolution.sln" /Rebuild Release   /project "WG.SiteClientSetup\WG.SiteClientSetup.vdproj" /projectconfig Release

