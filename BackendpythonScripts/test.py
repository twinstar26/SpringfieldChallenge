import spacy
from spacy import displacy
from collections import Counter
from pprint import pprint
import en_core_web_sm

fread = open('Period.txt','r')
string = fread.readline()

#Loading the corpus
nlp = en_core_web_sm.load()

# Forming the object which stores keywords , Parts of Speech and the Named Entity.
doc = nlp(string)

#Pretty Print the entities of the Keywords.
pprint([(X.text,X.label_) for X in doc.ents])

#Pretty Print the entites with their BIO.
pprint([(X,X.ent_iob_,X.ent_type_) for X in doc])



