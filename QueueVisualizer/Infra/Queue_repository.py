from pysimplesoap.client import SoapClient

class Queue_repository(object):
    
    def __init__(self, wsdl):
        self.wsdl = wsdl

    def get_public_queues(self, ):
        client = SoapClient(wsdl= self.wsdl, trace=False)
        response = client.(a=1,b=2)
        result = response['AddResult']

    def get_private_queues():
        pass


    def purge_queue(queue_name):
        pass