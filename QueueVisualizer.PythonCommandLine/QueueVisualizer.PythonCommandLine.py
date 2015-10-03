from pysimplesoap.client import SoapClient


client = SoapClient(wsdl= 'http://localhost:7789/QueueService.svc?wsdl', trace = False)
response = client.GetAll(entity = { 'IsPublic': False, 'QueueName': '' })
result = response['GetAllResult']
for queue in result['Queues']:
    queueEntity = queue['QueueEntity']
    print queueEntity['QtyMsg'], queueEntity['QueueName']
