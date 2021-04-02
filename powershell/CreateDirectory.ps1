function Add-Directory {
 param (
        $RootDirName
    )
# System.DateTime| Get-Member -static 查看对象的方法
 #获取当前日期  
 $currentDir=[System.IO.Path]::Combine($RootDirName,[System.DateTime]::Now.ToString('yyyyMMdd'))
 #创建目录
  [System.IO.Directory]::CreateDirectory($currentDir)
 #复制 文件到文件加
   
}

Add-Directory -RootDirName H:\xiaomayi