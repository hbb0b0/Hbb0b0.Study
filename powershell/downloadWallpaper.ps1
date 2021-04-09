function Resolve-Directory {
    param (
        [Parameter(Mandatory)]
        [string]
        $path
    )

    if (-not (Test-Path -LiteralPath $path)) {
        New-Item -Path $path -ItemType Directory -ErrorAction SilentlyContinue
    }

}

function Get-Image {
    param (
        [Parameter(Mandatory)]
        [string]
        $path,

        [Parameter(Mandatory)]
        [string]
        $url
    )
    #init target directory
    Resolve-Directory -path $path
    $global:web = New-Object System.Net.WebClient
    $response = $web.DownloadString($url)
    $content = ([regex]'<link\s*\w*id=[\"]+(.*?)[\"\s\w]*href=[\"]+(.*?)[\"]+\s*/>').Match($response).Value
    $href = ([regex]'href=[\"]+(.*?)[\"]').Match($content).Value
    $href = $href.Replace('"', "").Replace('href=', "")
    $href
}

function Invoke-MD5 {
    param (
        # Parameter Path
        [Parameter(Mandatory)]
        [string]
        $Path
    )

    begin {
        $global:hashTable = @{ }
    }

    process {
        Get-ChildItem -Path $Path | Where-Object {
            $hash = Get-FileHash -Path $_.FullName -Algorithm MD5
            $hashTable[$hash.Hash] = $hash.Path
        }
    }
    end {

    }
}

function Resolve-WallPaper {
    
    $dir = "D:\temp\wallpaper"
    $url = "https://cn.bing.com"
 if([System.IO.Directory]::Exists( $dir ))
 {
    Write-Output '目录已存在'
    #return 
 }
 else
 { 
    [System.IO.Directory]::CreateDirectory($dir )
 }
    Invoke-MD5 -Path $dir
    $imageUrl = Get-Image -url $url -path $dir
    $fileName = -join ([char[]](65..90 + 97..122) | Get-Random -Count 6) + ".jpg"
    $fullPath = Join-Path -Path $dir $fileName
    $web.DownloadFile(($url + $imageUrl), $fullPath)

    #calculate the md5 value
    $hashValue = (Get-FileHash -Path $fullPath -Algorithm MD5).Hash
    $oldFile = $hashTable[$hashValue]
    if (($oldFile) -and (Test-Path -Path $oldFile)) {
        Remove-Item -Path $fullPath -Force -ErrorAction SilentlyContinue
        $fullPath = $oldFile
    }
    # Setting wallpaper to the regisrty.
    #Set-ItemProperty -path 'HKCU:\Control Panel\Desktop\' -name wallpaper -value $fullPath
    # updating the user settings
    #rundll32.exe user32.dll, UpdatePerUserSystemParameters
    #rundll32.exe user32.dll, UpdatePerUserSystemParameters
    #rundll32.exe user32.dll, UpdatePerUserSystemParameters

    #explorer.exe $dir
}

Resolve-WallPaper