thisdir = class/System.Web.Routing
SUBDIRS = 
include ../../build/rules.make

LIBRARY = System.Web.Routing.dll
LIB_MCS_FLAGS = \
	        /r:System.dll \
	        /r:System.Core.dll \
	        /r:System.Web.dll \
	        /r:System.Web.Abstractions.dll

ifdef DEBUG
LIB_MCS_FLAGS += -define:DEBUG
endif

TEST_MCS_FLAGS = $(LIB_MCS_FLAGS)

EXTRA_DISTFILES =

# This is a .NET 3.5+ assembly
VALID_PROFILE := $(filter net_4_0 net_4_5, $(PROFILE))
ifndef VALID_PROFILE
LIBRARY_NAME = dummy-System.Web.Routing.dll
NO_INSTALL = yes
NO_SIGN_ASSEMBLY = yes
NO_TEST = yes
endif

include ../../build/library.make
