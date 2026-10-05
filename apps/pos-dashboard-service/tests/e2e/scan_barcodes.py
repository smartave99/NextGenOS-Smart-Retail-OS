"""Reads the Code 128 barcode in every cell of a printed page, for barcodes.e2e.js.

    python3 scan_barcodes.py page.png '{"dpi": 300, "cells": [[x_mm, y_mm, w_mm, h_mm], ...]}'

Prints a JSON list with the text read in each cell, or null where nothing was read. Needs zxing-cpp and Pillow
(pip install zxing-cpp pillow), an independent reader, so the check does not trust the app's own encoder.
"""
import json
import sys

import zxingcpp
from PIL import Image


def main():
    image = Image.open(sys.argv[1]).convert("L")
    layout = json.loads(sys.argv[2])
    per_mm = layout["dpi"] / 25.4
    found = []
    for x, y, w, h in layout["cells"]:
        cell = image.crop((int(x * per_mm), int(y * per_mm), int((x + w) * per_mm), int((y + h) * per_mm)))
        read = zxingcpp.read_barcodes(cell, formats=zxingcpp.BarcodeFormat.Code128)
        found.append(read[0].text if read else None)
    print(json.dumps(found))


if __name__ == "__main__":
    main()
