import io
from PIL import Image
import pytesseract
from wand.image import Image as wi
import sys

pdf_path = sys.argv[1]

file_ = pdf_path
in1 = file_.find('/')
file_ = file_[in1+1:-1]
in2 = file_.find('.')
file_ = file_[0:in2]
file_=file_+'.txt'

print('Preparing for OCR.')

l = []

pdf = wi(filename=pdf_path,resolution=300)
pdfImage=pdf.convert('jpeg')

imageBlobs=[]

for img in pdfImage.sequence:
	imgPage=wi(image=img)
	imageBlobs.append(imgPage.make_blob('jpeg'))

print('Extracting text.')

i=0
for imgBlob in imageBlobs:
	im=Image.open(io.BytesIO(imgBlob))
	text=pytesseract.image_to_string(im,lang='eng',config='-psm 6')
	i+=1	
	print("Page "+str(i)+" Completed.")
	l.append(text)
	
final_l=[]
for string in l:
	string=string.replace('\n',' ')
	string=string.replace('  ',' ')
	final_l.append(string)

final_txt = " ".join(final_l)
fwrite1 = open(file_,'w')
fwrite1.write(final_txt)

print('Text Extraction Completed.')	
