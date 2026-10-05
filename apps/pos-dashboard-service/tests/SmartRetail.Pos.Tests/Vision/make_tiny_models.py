# Makes two tiny ONNX models that stand in for DINOv2 in the dashboard's tests: the same input ("pixel_values",
# N x 3 x 224 x 224) and the same outputs, but each vector is only the image's mean colour times a fixed matrix.
import numpy as np
import onnx
from onnx import TensorProto, helper, numpy_helper

W = np.array([[1.0, 0.2, -0.5, 0.0, 0.3, 0.1],
              [0.1, 1.0, 0.4, -0.3, 0.0, 0.2],
              [-0.2, 0.3, 1.0, 0.5, 0.1, 0.0]], dtype=np.float32)
pixels = helper.make_tensor_value_info("pixel_values", TensorProto.FLOAT, ["batch", 3, 224, 224])

def model(outputs, nodes, name, extra=()):
    graph = helper.make_graph(nodes, name, [pixels], outputs, [numpy_helper.from_array(W, "w"), *extra])
    m = helper.make_model(graph, opset_imports=[helper.make_opsetid("", 13)], producer_name="smart-retail-tests")
    m.ir_version = 8
    onnx.checker.check_model(m)
    return m

# pooler_output: N x 6.
pooled = model(
    [helper.make_tensor_value_info("pooler_output", TensorProto.FLOAT, ["batch", 6])],
    [helper.make_node("ReduceMean", ["pixel_values"], ["mean"], axes=[2, 3], keepdims=0),
     helper.make_node("MatMul", ["mean", "w"], ["pooler_output"])],
    "tiny-pooled")
onnx.save(pooled, "tiny-embedder.onnx")

# last_hidden_state only: N x 2 x 6, the first token being the same vector (as DINOv2's CLS token is).
cls = model(
    [helper.make_tensor_value_info("last_hidden_state", TensorProto.FLOAT, ["batch", 2, 6])],
    [helper.make_node("ReduceMean", ["pixel_values"], ["mean"], axes=[2, 3], keepdims=0),
     helper.make_node("MatMul", ["mean", "w"], ["vector"]),
     helper.make_node("Unsqueeze", ["vector", "one"], ["token"]),
     helper.make_node("Neg", ["token"], ["other"]),
     helper.make_node("Concat", ["token", "other"], ["last_hidden_state"], axis=1)],
    "tiny-tokens",
    [numpy_helper.from_array(np.array([1], dtype=np.int64), "one")])
onnx.save(cls, "tiny-embedder-tokens.onnx")
