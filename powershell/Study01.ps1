#查看当前 powershell的版本
$PSVersionTable

#Get-Help 是多用途命令。 Get-Help 帮助你了解找到命令后如何使用它们。 Get-Help 也可用于帮助查找命令，但与 Get-Command 相比，它采用不同且较为间接的方式
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

#Get-Command 的作用是帮助查找命令。 运行不带任何参数的 Get-Command 会返回系统上所有命令的列表。 以下示例演示使用 Get-Command cmdlet 确定存在的用于处理进程的命令：