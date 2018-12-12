'''
Rates : Whole
Period : ' ','herein.^l'
Attaching_To_Delegated... : Whole
Insured : ' ','and/or^s'
Interest : 'consisting','handled^l'
Unique_Market_Reference : Whole
Type : Whole
'''
def EntityEx(filename , flag):
	fread = open(filename,'r')
	string = fread.readline()
	flag = flag[1:-1]
	t = flag.partition(',')
	start = t[0].strip('\'')
	end = t[2].strip('\'')
	final_str=str()
	if start=='' and end=='':
		final_str=string
	elif start=='':
		t1 = end.partition('^')
		end = t1[0]
		mode = t1[2]
		if mode=='s':
			index = string.find(end)
			final_str = string[:index]
		else:
			index = string.rfind(end)
			final_str = string[:index]
	elif end=='':
		t1 = start.partition('^')
		start = t1[0]
		mode=t1[2]
		if mode=='s':
			index = string.find(end)
			final_str = string[index:]
		else:
			index = string.rfind(end)
			final_str = string[index:]
	else:
		t1 = start.partition('^')
		start = t1[0]
		mode1=t1[2]
		t2 = end.partition('^')
		end = t2[0]
		mode2=t2[2]
		sin,ein=0,0
		if mode1=='s':
			sin = string.find(start)
		else:
			sin = string.rfind(start)
		if mode2=='s':
			ein = string.find(end)
		else:
			ein = string.rfind(end)
		final_str = string[sin:ein]
	print(final_str)
	return final_str
	
	
	
