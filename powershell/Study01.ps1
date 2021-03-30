#查看当前 powershell的版本
$PSVersionTable

#检查当前的执行策略
Get-ExecutionPolicy

#获取帮助
Get-Help -Name Get-Help

#获取全部的帮助
Get-Help -Name Get-Help -Full

#Get-Help 示例
#获取所有结尾为*process的命令
get-help *process
#获取 Get-Process 的帮助
Get-help -name get-process

#查看进程的信息
Get-Process OpenConsole

#查看进程的文件信息
Get-Process OpenConsole -FileVersionInfo