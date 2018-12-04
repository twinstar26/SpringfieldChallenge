from pdfminer.pdfinterp import PDFResourceManager, PDFPageInterpreter
from pdfminer.converter import TextConverter
from pdfminer.layout import LAParams
from pdfminer.pdfpage import PDFPage
from io import StringIO
import sys
import argparse
import re
import nltk
from nltk.corpus import stopwords
from nltk.stem.porter import PorterStemmer
import numpy as np
import pandas as pd
from sklearn.feature_extraction.text import CountVectorizer

'''
    CODE FOR READING TEXT FROM THE PDF.
'''
parser = argparse.ArgumentParser(description=Path of a document)
parser.add_argument('--path', dest='pathoffile')
args = parser.parse_args()
path = args.pathoffile
rsrcmgr = PDFResourceManager()
retstr = StringIO()
codec = 'utf-8'
laparams = LAParams()
device = TextConverter(rsrcmgr, retstr, codec=codec, laparams=laparams)
fp = open(path, 'rb')
interpreter = PDFPageInterpreter(rsrcmgr, device)
password = ""
maxpages = 0
caching = True
pagenos=set()
for page in PDFPage.get_pages(fp, pagenos, maxpages=maxpages, password=password,caching=caching, check_extractable=True):
    interpreter.process_page(page)
text = retstr.getvalue()
print(text)
fp.close()
device.close()
retstr.close()

'''
    DOWNLOADING STOPWORDS.
'''
nltk.download('stopwords')

'''
	GETTING RID OF UNWANTED PUNCTUATIONS.
'''
text = re.sub('[^a-zA-Z]',' ',text)

'''
	LOWERING THE ALPHABETS.
'''
text = text.lower()

'''
	STEMMING AND GETTING RID OF STPWORDS.
'''
text = text.split()
ps = PorterStemmer()
text = [ps.stem(word) for word in text if word not in set(stopwords.words('english'))]

'''
	JOINING THE RESULTS.
'''
text = ' '.join(text)

'''
	MAKING A OBJECT OF COUNT-VECTORIZER.
'''
cv = CountVectorizer(max_features=500)
final = cv.fit_transform(text.reshape(1,1)).toarray()
