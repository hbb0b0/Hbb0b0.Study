#�鿴��ǰ powershell�İ汾
$PSVersionTable

#Get-Help �Ƕ���;��� Get-Help �������˽��ҵ���������ʹ�����ǡ� Get-Help Ҳ�����ڰ�������������� Get-Command ��ȣ������ò�ͬ�ҽ�Ϊ��ӵķ�ʽ
#��鵱ǰ��ִ�в���
Get-ExecutionPolicy

#��ȡ����
Get-Help -Name Get-Help

#��ȡȫ���İ���
Get-Help -Name Get-Help -Full

#Get-Help ʾ��
#��ȡ���н�βΪ*process������
get-help *process
#��ȡ Get-Process �İ���
Get-help -name get-process

#�鿴���̵���Ϣ
Get-Process OpenConsole

#�鿴���̵��ļ���Ϣ
Get-Process OpenConsole -FileVersionInfo

#Get-Command �������ǰ���������� ���в����κβ����� Get-Command �᷵��ϵͳ������������б� ����ʾ����ʾʹ�� Get-Command cmdlet ȷ�����ڵ����ڴ�����̵����