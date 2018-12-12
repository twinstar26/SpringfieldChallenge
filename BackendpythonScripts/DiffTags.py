import sys
from EntityExtractor import EntityEx

def Lookup (filename , string):
	fread=open(filename,'r')
	l = fread.readlines()
	d = dict()
	for s in l:
		s=s.strip('\n')
		index = string.find(s)
		if index!=-1:
			d[s]=index
	return d

file_txt = sys.argv[1]
fread =  open(file_txt,'r')
final_txt = fread.readline() 

lookup = Lookup(sys.argv[2],final_txt)

Index = []
for index in lookup:
	Index.append(lookup[index])

Index.sort()
Index.append(-1)

length = len(sys.argv)
for i in range(3,length):
	index = sys.argv[i].find('[')
	s1 = sys.argv[i][:index]
	s2 = sys.argv[i][index:]
	s3 = s1.replace('_',' ')
	s3=s3+":"
	if s3 in lookup.keys():
		start = lookup[s3]
		end = Index[Index.index(start)+1]
		fwrite = open(s1+'.txt','w') 
		fwrite.write(final_txt[start:end])
		fwrite.close()
		EntityEx(s1+'.txt',s2)

print('Done')
