Function Test-Function {
    Param      
        (       
        [parameter(Mandatory=$true)]$Name,       
        $Age = "18"       
        )
    Write-Host "$Name  $Age 岁."      
}

Test-Function 
