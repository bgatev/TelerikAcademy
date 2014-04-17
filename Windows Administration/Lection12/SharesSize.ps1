function ShowSize($PCName = $env:Computername)
{
    $allShares = Get-WmiObject -Class Win32_Share -ComputerName $PCName -filter "type=0" #without administrative shares
    #$allShares = Get-WmiObject -Class Win32_Share -ComputerName $PCName #with administrative shares

    $diskSpace = Get-WmiObject Win32_LogicalDisk -ComputerName $PCName | Select-Object DeviceID, Size, FreeSpace

    foreach ($share in $allShares) 
    {
        $sharesDrive = $share.path.Substring(0,2)
        
        foreach($device in $diskSpace)
        {
            if($sharesDrive -eq $device.DeviceID)
            {
                $logDiskDrive = $device.DeviceID
                $driveSize = [string]([math]::Round(($device.Size/1GB),3)) + " GB"
                $driveFreeSpace = [string]([math]::Round(($device.FreeSpace/1GB),3)) + " GB"
                break  
            }
        }
        Write-Host "Calculating size of $($share.path)" -ForegroundColor Green

        $stats=Get-ChildItem $share.path -Recurse -ErrorAction SilentlyContinue | Where {-Not $_.PSIscontainer} | Measure-Object -Property Length -Sum

        $shareInfo = @{
            Computername = $PCName
            Path = $share.path
            ShareName = $share.Name
            ShareSizeMB = [string]([math]::Round(($stats.sum/1MB),2)) + " MB"
            ShareFiles = $stats.count
            LogicalDiskDrive = $logDiskDrive
            DriveSizeGB = $driveSize
            DriveFreeSpaceGB = $driveFreeSpace
        }
        New-Object -TypeName PSObject -Property $shareInfo
    }
}
ShowSize ad-8
